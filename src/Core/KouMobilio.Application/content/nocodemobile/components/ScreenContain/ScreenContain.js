import {View, TouchableOpacity, Text} from 'react-native';
import React, {Fragment} from 'react';
import fakeData from '../../fakeData';
import Button from '../Button/Button';
import Image from '../ImageComp/Image';
import ContainParent from '../ContainParent/ContainParent';
import TextInput from '../TextInput/TextInput';
import Title from '../Title/Title';
import Switch from '../Switch/Switch';
import LoadingComp from '../LoadingComp/LoadingComp';
import {useDispatch, useSelector} from 'react-redux';
const ScreenContain = ({screenIndex, navigation}) => {
  const {myScreenData} = useSelector(state => state.screen1);
  return (
    <View style={{flex: 1}}>
      {myScreenData[screenIndex].lastDroppedItem.map((item, index) => {
        return (
          <Fragment key={item.priviteName}>
            {item.name === 'Button' ? (
              <Button item={item} navigation={navigation} />
            ) : item.name === 'Image' ? (
              <Image item={item} />
            ) : item.name === 'Contain' ? (
              <ContainParent
                item={item}
                screenIndex={screenIndex}
                index={index}
              />
            ) : item.name === 'Text Input' ? (
              <TextInput item={item} screenIndex={screenIndex} index={index} />
            ) : item.name === 'Title' ? (
              <Title item={item} />
            ) : item.name === 'Switch' ? (
              <Switch item={item} />
            ) : item.name === 'Loading' ? (
              <LoadingComp item={item} />
            ) : null}
          </Fragment>
        );
      })}
    </View>
  );
};

export default ScreenContain;
