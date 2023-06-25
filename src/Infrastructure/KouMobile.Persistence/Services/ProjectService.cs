using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using KouMobilio.Application.Abstraction.Services;
using KouMobilio.Application.DTOs.Project.Inputs;
using KouMobilio.Application.DTOs.Project.Outputs;
using KouMobilio.Application.Exceptions;
using KouMobilio.Application.Repositories;
using KouMobilio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KouMobile.Persistence.Services;

public class ProjectService : IProjectService
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(CreateProjectDto input)
    {
        var exist = await _repository.GetAsync(r => r.Name.ToLower() == input.Name);
        if (exist != null)
        {
            throw new ProjectNameAlreadyExistsException(input.Name);
        }
        
         var projectId = await _repository.AddAsync(_mapper.Map<Project>(input), true);
         return projectId;
    }

    public async Task<ProjectDetailDto> GetAsync(Guid id)
    {
        return _mapper.Map<ProjectDetailDto>(await _repository.GetByIdAsync(id));
    }

    public async Task<List<ProjectDto>> GetListAsync()
    {

        return _mapper.Map<List<ProjectDto>>(await _repository.GetAllAsync());
    }

    public async Task UpdateAsync(Guid id, UpdateProjectDto input)
    {
        var model = await _repository.GetByIdAsync(id);
        var res = _mapper.Map<UpdateProjectDto, Project>(input, model);
        await _repository.UpdateAsync(res, true);
    }

    public async Task UpdateNameAsync(Guid id, string name)
    {
        var exist = await _repository.GetAsync(r => r.Name.ToLower() == name.ToLower());
        if (exist != null)
        {
            throw new ProjectNameAlreadyExistsException(name);
        }
        var model = await _repository.GetByIdAsync(id);
        model.Name = name;
        await _repository.UpdateAsync(model, true);
    }

    public Task DeleteAsync(Guid id)
    {
        return _repository.RemoveAsync(id, true);
    }

    public async Task<IActionResult> DownloadAsync(Guid id)
    {
        var project = await _repository.GetByIdAsync(id);
        string folderPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/content/nocodemobile";
        string configFilePath = Path.Combine(folderPath, "fakeData.js");
        
        var formattedContent = FormatJson(project.Content);
        File.WriteAllText(configFilePath, $"export default {formattedContent};");
        
        MemoryStream memoryStream = new MemoryStream();
         
        using (ZipArchive zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
        {
            // Klasördeki dosyaları zip dosyasına ekle
            string[] filePaths = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetRelativePath(folderPath, filePath);
                ZipArchiveEntry entry = zipArchive.CreateEntry(fileName, CompressionLevel.Optimal);
                using (Stream fileStream = entry.Open())
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    file.CopyTo(fileStream);
                }
            }
        }
        
        memoryStream.Position = 0;
        var result = new FileStreamResult(memoryStream, "application/zip");
        result.FileDownloadName = $"{project.Name}_{DateTime.Now.ToString().Replace(" ", "-")}.zip";
        return result;
    }
    
    private string FormatJson(string jsonData)
    {
        if (string.IsNullOrWhiteSpace(jsonData))
        {
            return string.Empty;
        }

        // JSON verisini düzgün biçimde formatlama
        using (JsonDocument document = JsonDocument.Parse(jsonData))
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            byte[] formattedData = JsonSerializer.SerializeToUtf8Bytes(document.RootElement, options);
            return Encoding.UTF8.GetString(formattedData);
        }
    }
}