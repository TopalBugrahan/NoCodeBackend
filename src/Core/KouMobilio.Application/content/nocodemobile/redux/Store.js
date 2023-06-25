import {configureStore} from '@reduxjs/toolkit';
import slice from './Slice';
export default store = configureStore({
  reducer: {
    screen1: slice,
  },
});
