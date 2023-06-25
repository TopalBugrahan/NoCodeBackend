import {Dimensions} from 'react-native';
const mobileRatio = (top, left, width, height) => {
  const newTop = (Dimensions.get('window').height * top) / 500;
  const newLeft = (Dimensions.get('window').width * left) / 300;
  const w = Dimensions.get('window').width;
  const h = Dimensions.get('window').height;
  let newWidth, newHeight;
  if (width === height) {
    newWidth = (w * width) / 300;
    newHeight = newWidth;
  } else {
    newWidth = (w * width) / 300;
    newHeight = (h * height) / 500;
  }

  return {newTop, newLeft, newWidth, newHeight};
};

export default mobileRatio;
