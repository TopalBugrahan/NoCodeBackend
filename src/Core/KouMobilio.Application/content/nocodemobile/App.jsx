import React, {useEffect} from 'react';
import {NavigationContainer} from '@react-navigation/native';
import {createNativeStackNavigator} from '@react-navigation/native-stack';
import Screen from './components/Screen/Screen';
import fakeData from './fakeData';
import {useDispatch, useSelector} from 'react-redux';
const Stack = createNativeStackNavigator();

const App = () => {
  const {myScreenData} = useSelector(state => state.screen1);

  return (
    <NavigationContainer>
      <Stack.Navigator>
        {myScreenData.map((item, index) => {
          return (
            <Stack.Screen
              key={item.name}
              name={item.name}
              options={{
                headerShown: false,
              }}>
              {props => <Screen {...props} screenIndex={index} />}
            </Stack.Screen>
          );
        })}
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;
