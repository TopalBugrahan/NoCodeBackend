import {View, Text, TextInput} from 'react-native';
import React from 'react';
import mobileRatio from '../../units/mobileRatio';
import {changeTextInputValue} from '../../redux/Slice';
import clickEventForAllComp from '../../units/clickEventForAllComp';
import clickEventForRestful from '../../units/clickEventForRestful';
import clickEventForCondition from '../../units/clickEventForCondition';
import clickEventForNavigate from '../../units/clickEventForNavigate';
import {changeTitleText} from '../../redux/Slice';
import {useDispatch, useSelector} from 'react-redux';
import clickEventForAccount from '../../units/clickEventForAccount';
const TextInputC = ({item, screenIndex, index, contain_index, navigation}) => {
  const showToast = () => {
    ToastAndroid.show('Hata Aldınız !', ToastAndroid.SHORT);
  };
  const showToastForRestful = () => {
    ToastAndroid.show('İleminiz başarıyla gerçekleşti!', ToastAndroid.SHORT);
  };
  const {myScreenData} = useSelector(state => state.screen1);
  const dispatch = useDispatch();
  let {
    backgroundColor,
    font_size,
    height,
    left,
    text,
    text_color,
    top,
    width,
    borderColor,
    borderWidth,
    borderRedius,
    hint,
    keyboard,
    globalStyle,
    actions,
    visibility,
  } = item;

  if (globalStyle !== null) {
    const globalSty = globalStyle.styles;
    backgroundColor = globalSty.backgroundColor;
    borderColor = globalSty.borderColor;
    (borderRedius = globalSty.borderRedius),
      (borderWidth = globalSty.borderWidth);
    font_size = globalSty.font_size;
    text_color = globalSty.text_color;
  }

  const {newTop, newHeight, newLeft, newWidth} = mobileRatio(
    top,
    left,
    width,
    height,
  );
  return (
    <View
      style={{
        position: 'absolute',
        top: newTop,
        left: newLeft,
        display: visibility ? 'flex' : 'none',
      }}>
      <TextInput
        placeholder={hint}
        secureTextEntry={keyboard === 'password' ? true : false}
        inputMode={
          keyboard === 'number'
            ? 'numeric'
            : keyboard === 'password'
            ? null
            : keyboard
        }
        onChangeText={data => {
          let text = data;
          if (keyboard === 'number') {
            text = Number(text);
          }
          dispatch(
            changeTextInputValue({
              text,
              screenIndex,
              contain_index,
              index,
              actions,
            }),
          );
        }}
        style={{
          height: newHeight,
          width: newWidth,
          backgroundColor,
          fontSize: font_size,
          color: text_color,
          borderColor,
          borderWidth,
          borderRadius: borderRedius,
          overflow: 'hidden',
        }}>
        {text}
      </TextInput>
    </View>
  );
};

export default TextInputC;
