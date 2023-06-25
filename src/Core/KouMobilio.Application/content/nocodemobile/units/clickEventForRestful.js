const clickEventForRestful = async (
  actions,
  myScreenData,
  isComeingCondition,
) => {
  for (const action of actions) {
    const isCondition = action.params.conditionIndex;
    if (isCondition === null || isComeingCondition === true) {
      if (action.event === 'restful_get') {
        try {
          const uri = action.params.uri;
          const selectTitle = action.params.selectTitle;
          const response = await fetch(uri);
          const restData = await response.json();

          return [selectTitle, restData];
        } catch (error) {
          return [null, 'error'];
        }
      } else if (action.event === 'restful_post') {
        const uri = action.params.uri;
        let bodyObj;
        action.params.selectEmail.forEach(item => {
          const indexes = JSON.parse(item[0]);
          let value =
            myScreenData[indexes.screenIndex].lastDroppedItem[indexes.index]
              .text;
          if (indexes.contain_index !== 'undefined') {
            value =
              myScreenData[indexes.screenIndex].lastDroppedItem[indexes.index]
                .items[contain_index].text;
          }
          bodyObj = {
            ...bodyObj,
            [item[1]]: value,
          };
        });
        const settings = {
          method: 'POST',
          body: bodyObj,
          headers: {
            'Content-type': 'application/json; charset=UTF-8',
          },
        };
        try {
          const fetchResponse = await fetch(uri, settings);
          const data = await fetchResponse.json();
          return [null, 'post'];
        } catch (error) {
          return [null, 'error'];
        }
      } else if (action.event === 'restful_put') {
        const uri = action.params.uri;
        let bodyObj;
        action.params.selectEmail.forEach(item => {
          const indexes = JSON.parse(item[0]);
          let value =
            myScreenData[indexes.screenIndex].lastDroppedItem[indexes.index]
              .text;
          if (indexes.contain_index !== 'undefined') {
            value =
              myScreenData[indexes.screenIndex].lastDroppedItem[indexes.index]
                .items[contain_index].text;
          }
          bodyObj = {
            ...bodyObj,
            [item[1]]: value,
          };
        });
        const settings = {
          method: 'PUT',
          body: bodyObj,
          headers: {
            'Content-type': 'application/json; charset=UTF-8',
          },
        };
        try {
          const fetchResponse = await fetch(uri, settings);
          const data = await fetchResponse.json();
          return [null, 'put'];
        } catch (error) {
          return [null, 'error'];
        }
      } else if (action.event === 'restful_delete') {
        const uri = action.params.uri;
        const settings = {
          method: 'DELETE',
        };
        try {
          const fetchResponse = await fetch(uri, settings);
          const data = await fetchResponse.json();
          return [null, 'delete'];
        } catch (error) {
          return [null, 'error'];
        }
      }
    }
  }
  return [null, null];
};
export default clickEventForRestful;
