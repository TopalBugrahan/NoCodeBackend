import {Text, ToastAndroid, TouchableOpacity} from 'react-native';
import React, {useState} from 'react';
import mobileRatio from '../../units/mobileRatio';
import clickEventForAllComp from '../../units/clickEventForAllComp';
import clickEventForRestful from '../../units/clickEventForRestful';
import clickEventForCondition from '../../units/clickEventForCondition';
import clickEventForNavigate from '../../units/clickEventForNavigate';
import {changeTitleText} from '../../redux/Slice';
import {useDispatch, useSelector} from 'react-redux';
import clickEventForAccount from '../../units/clickEventForAccount';
const ButtonComp = ({item, navigation}) => {
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
    height,
    width,
    left,
    top,
    borderColor,
    borderWidth,
    borderStyle,
    borderRedius,
    font_size,
    text,
    priviteName,
    actions,
    text_color,
    globalStyle,
    visibility,
  } = item;

  if (globalStyle !== null) {
    const globalSty = globalStyle.styles;
    backgroundColor = globalSty.backgroundColor;
    borderColor = globalSty.borderColor;
    (borderRedius = globalSty.borderRedius),
      (borderWidth = globalSty.borderWidth);
    borderStyle = globalSty.borderStyle;
    text_color = globalSty.text_color;
    font_size = globalSty.font_size;
  }

  const {newTop, newHeight, newLeft, newWidth} = mobileRatio(
    top,
    left,
    width,
    height,
  );
  return (
    <TouchableOpacity
      onPress={async () => {
        const accountData = await clickEventForAccount(
          actions,
          myScreenData,
          false,
        );
        if (accountData !== false) {
          const [selectTitle, restData] = await clickEventForRestful(
            actions,
            myScreenData,
            false,
          );
          if (restData === 'error') {
            showToast();
            return;
          }
          if (
            restData !== 'post' &&
            restData !== 'put' &&
            restData !== 'delete' &&
            restData !== null
          ) {
            dispatch(changeTitleText({selectTitle, restData}));
          }

          if (
            restData === 'post' ||
            restData === 'put' ||
            restData === 'delete'
          ) {
            showToastForRestful();
          }
          clickEventForAllComp(dispatch, actions, false, null);
          const [selectTitle1, restData1] = await clickEventForCondition(
            actions,
            myScreenData,
            dispatch,
            navigation,
          );
          if (restData1 === 'error') {
            showToast();
            return;
          }
          if (restData1 !== false) {
            if (
              restData1 !== 'post' &&
              restData1 !== 'put' &&
              restData1 !== 'delete' &&
              restData1 !== null &&
              selectTitle1 !== 'account++1'
            ) {
              dispatch(
                changeTitleText({
                  selectTitle: selectTitle1,
                  restData: restData1,
                }),
              );
            }
            if (
              restData === 'post' ||
              restData === 'put' ||
              restData === 'delete'
            ) {
              setTimeout(() => {
                clickEventForNavigate(actions, navigation, false);
              }, 2000);
            } else {
              clickEventForNavigate(actions, navigation, false);
            }
          }
        }
      }}
      style={{
        position: 'absolute',
        top: newTop,
        left: newLeft,
        width: newWidth,
        height: newHeight,
        backgroundColor,
        justifyContent: 'center',
        alignItems: 'center',
        borderColor,
        borderWidth,
        borderStyle,
        borderRadius: borderRedius,
        display: visibility ? 'flex' : 'none',
      }}>
      <Text style={{fontSize: font_size, color: text_color}}>{text}</Text>
    </TouchableOpacity>
  );
};

export default ButtonComp;
