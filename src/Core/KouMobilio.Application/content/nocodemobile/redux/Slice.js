import {createSlice, current} from '@reduxjs/toolkit';
import fakeData from '../fakeData';
export const screenSlice = createSlice({
  name: 'screen1',
  initialState: {
    myScreenData: fakeData,
  },
  reducers: {
    changeWidth: (state, action) => {
      const {data, width} = action.payload;
      const {contain_index, index, screenIndex} = data;
      if (contain_index === 'undefined') {
        state.myScreenData[screenIndex].lastDroppedItem[index].width = width;
      } else {
        state.myScreenData[screenIndex].lastDroppedItem[index].items[
          contain_index
        ].width = width;
      }
    },

    changeVisibility: (state, action) => {
      const {data} = action.payload;
      const {contain_index, index, screenIndex} = data;
      if (contain_index === 'undefined') {
        state.myScreenData[screenIndex].lastDroppedItem[index].visibility =
          !state.myScreenData[screenIndex].lastDroppedItem[index].visibility;
      } else {
        state.myScreenData[screenIndex].lastDroppedItem[index].items[
          contain_index
        ].visibility =
          !state.myScreenData[screenIndex].lastDroppedItem[index].items[
            contain_index
          ].visibility;
      }
    },

    changeHeight: (state, action) => {
      const {data, height} = action.payload;
      const {contain_index, index, screenIndex} = data;
      if (contain_index === 'undefined') {
        state.myScreenData[screenIndex].lastDroppedItem[index].height = height;
      } else {
        state.myScreenData[screenIndex].lastDroppedItem[index].items[
          contain_index
        ].height = height;
      }
    },

    changeTop: (state, action) => {
      const {data, top} = action.payload;
      const {contain_index, index, screenIndex} = data;
      if (contain_index === 'undefined') {
        state.myScreenData[screenIndex].lastDroppedItem[index].top = top;
      } else {
        state.myScreenData[screenIndex].lastDroppedItem[index].items[
          contain_index
        ].top = top;
      }
    },

    changeLeft: (state, action) => {
      const {data, left} = action.payload;
      const {contain_index, index, screenIndex} = data;
      if (contain_index === 'undefined') {
        state.myScreenData[screenIndex].lastDroppedItem[index].left = left;
      } else {
        state.myScreenData[screenIndex].lastDroppedItem[index].items[
          contain_index
        ].left = left;
      }
    },

    changeBackgroundColor: (state, action) => {
      const {data, color} = action.payload;
      const {contain_index, index, screenIndex} = data;
      if (contain_index === 'undefined') {
        state.myScreenData[screenIndex].lastDroppedItem[index].backgroundColor =
          color;
      } else {
        state.myScreenData[screenIndex].lastDroppedItem[index].items[
          contain_index
        ].backgroundColor = color;
      }
    },

    changeTextInputValue: (state, action) => {
      const {text, screenIndex, contain_index, index, actions} = action.payload;
      if (contain_index === undefined) {
        state.myScreenData[screenIndex].lastDroppedItem[index].text = text;
      } else {
        state.myScreenData[screenIndex].lastDroppedItem[index].items[
          contain_index
        ].text = text;
      }
      if (actions !== null) {
        for (const a of actions) {
          if (a.event === 'dynamic_value') {
            const {screenIndex, contain_index, index} = a.params.selectTitle;
            if (contain_index === 'undefined') {
              state.myScreenData[screenIndex].lastDroppedItem[index].text =
                text;
            } else {
              state.myScreenData[screenIndex].lastDroppedItem[index].items[
                contain_index
              ].text = text;
            }
          }
        }
      }
    },

    changeTitleText: (state, action) => {
      const {selectTitle, restData} = action.payload;
      const {screenIndex, contain_index, index} = selectTitle;
      if (contain_index === 'undefined') {
        state.myScreenData[screenIndex].lastDroppedItem[index].text =
          JSON.stringify(restData);
      } else {
        state.myScreenData[screenIndex].lastDroppedItem[index].items[
          contain_index
        ].text = JSON.stringify(restData);
      }
    },
  },
});

export const {
  changeWidth,
  changeVisibility,
  changeHeight,
  changeTop,
  changeLeft,
  changeBackgroundColor,
  changeTextInputValue,
  changeTitleText,
} = screenSlice.actions;
export default screenSlice.reducer;
