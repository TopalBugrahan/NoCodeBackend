import {View, ImageBackground, Button} from 'react-native';
import React from 'react';
import ScreenContain from '../ScreenContain/ScreenContain';
import fakeData from '../../fakeData';

const Screen = ({screenIndex, navigation}) => {
  const image = {
    uri: fakeData[screenIndex].backgroundImage,
  };
  const color = fakeData[screenIndex].backgroundColor;
  return (
    <View style={{flex: 1, position: 'relative', backgroundColor: color}}>
      {fakeData[screenIndex].backgroundImage !== null ? (
        <ImageBackground source={image} resizeMode="cover" style={{flex: 1}}>
          <ScreenContain screenIndex={screenIndex} navigation={navigation} />
        </ImageBackground>
      ) : (
        <ScreenContain screenIndex={screenIndex} navigation={navigation} />
      )}
    </View>
  );
};

export default Screen;
