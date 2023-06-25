import {View, Text, TouchableOpacity} from 'react-native';
import React from 'react';
import mobileRatio from '../../units/mobileRatio';
import Button from '../Button/Button';
import TextInput from '../TextInput/TextInput';
import Image from '../ImageComp/Image';
import LoadingComp from '../LoadingComp/LoadingComp';
import clickEventForAllComp from '../../units/clickEventForAllComp';
import clickEventForRestful from '../../units/clickEventForRestful';
import clickEventForCondition from '../../units/clickEventForCondition';
import clickEventForNavigate from '../../units/clickEventForNavigate';
import {changeTitleText} from '../../redux/Slice';
import {useDispatch, useSelector} from 'react-redux';
import clickEventForAccount from '../../units/clickEventForAccount';
const ContainParent = ({item, screenIndex, index, navigation}) => {
  const showToast = () => {
    ToastAndroid.show('Hata Aldınız !', ToastAndroid.SHORT);
  };
  const showToastForRestful = () => {
    ToastAndroid.show('İleminiz başarıyla gerçekleşti!', ToastAndroid.SHORT);
  };
  const {myScreenData} = useSelector(state => state.screen1);
  const dispatch = useDispatch();
  let {
    items,
    top,
    left,
    width,
    height,
    borderColor,
    borderWidth,
    borderRedius,
    backgroundColor,
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
        left: newLeft,
        top: newTop,
        height: newHeight,
        width: newWidth,
        borderColor,
        borderWidth,
        borderRadius: borderRedius,
        backgroundColor,
        display: visibility ? 'flex' : 'none',
      }}>
      {items.map((item, contain_index) => {
        return (
          <React.Fragment key={item.priviteName}>
            {item.name === 'Button' ? (
              <Button item={item} />
            ) : item.name === 'Image' ? (
              <Image item={item} />
            ) : item.name === 'Contain' ? (
              <ContainParent item={item} />
            ) : item.name === 'Text Input' ? (
              <TextInput
                item={item}
                index={index}
                screenIndex={screenIndex}
                contain_index={contain_index}
              />
            ) : item.name === 'Title' ? (
              <Title item={item} />
            ) : item.name === 'Switch' ? (
              <Switch item={item} />
            ) : item.name === 'Loading' ? (
              <LoadingComp item={item} />
            ) : null}
          </React.Fragment>
        );
      })}
    </TouchableOpacity>
  );
};

export default ContainParent;
