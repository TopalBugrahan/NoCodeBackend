import clickEventForRestful from './clickEventForRestful';
import clickEventForAllComp from './clickEventForAllComp';
import clickEventForNavigate from './clickEventForNavigate';
import clickEventForAccount from './clickEventForAccount';
const clickEventForCondition = async (
  actions,
  myScreenData,
  dispatch,
  navigation,
) => {
  for (const action of actions) {
    const isCondition = action.params.conditionIndex;
    if (isCondition !== null) {
      if (action.event === 'condition') {
        const condition = action.params.condition;
        if (condition.length === 5) {
          const value1 = condition[0].value;
          const value2 = condition[1].value;
          const value3 = condition[2].value;
          const value4 = condition[3].value;
          const value5 = condition[4].label;
          let element1;
          let element2;
          if (value1.contain_index === 'undefined') {
            element1 =
              myScreenData[value1.screenIndex].lastDroppedItem[value1.index];
          } else {
            element1 =
              myScreenData[value1.screenIndex].lastDroppedItem[value1.index]
                .items[value1.contain_index];
          }
          if (value4.contain_index === 'undefined') {
            element2 =
              myScreenData[value4.screenIndex].lastDroppedItem[value4.index];
          } else {
            element2 =
              myScreenData[value4.screenIndex].lastDroppedItem[value4.index]
                .items[value4.contain_index];
          }
          if (value2 === 'width') {
            element1 = element1.width;
          } else if (value2 === 'height') {
            element1 = element1.height;
          }
          if (value5 === 'width') {
            element2 = element2.width;
          } else if (value5 === 'height') {
            element2 = element2.height;
          }
          element1 = 140;
          if (value3 === 1) {
            if (element1 > element2) {
              const actionIndex = action.params.conditionIndex;
              const event = actions[isCondition].event;
              let [selectTitle, restData] = await conditionFunc(
                event,
                actions,
                myScreenData,
                dispatch,
                navigation,
                actions[actionIndex],
              );
              if (restData !== null) {
                return [selectTitle, restData];
              }
            }
          } else if (value3 === 2) {
            if (element1 < element2) {
              const actionIndex = action.params.conditionIndex;
              const event = actions[isCondition].event;
              let [selectTitle, restData] = await conditionFunc(
                event,
                actions,
                myScreenData,
                dispatch,
                navigation,
                actions[actionIndex],
              );
              if (restData !== null) {
                return [selectTitle, restData];
              }
            }
          } else if (value3 === 3) {
            if (element1 === element2) {
              const actionIndex = action.params.conditionIndex;
              const event = actions[isCondition].event;
              let [selectTitle, restData] = await conditionFunc(
                event,
                actions,
                myScreenData,
                dispatch,
                navigation,
                actions[actionIndex],
              );
              if (restData !== null) {
                return [selectTitle, restData];
              }
            }
          } else if (value3 === 4) {
            if (element1 <= element2) {
              const actionIndex = action.params.conditionIndex;
              const event = actions[isCondition].event;
              let [selectTitle, restData] = await conditionFunc(
                event,
                actions,
                myScreenData,
                dispatch,
                navigation,
                actions[actionIndex],
              );
              if (restData !== null) {
                return [selectTitle, restData];
              }
            }
          } else {
            if (element1 >= element2) {
              const actionIndex = action.params.conditionIndex;
              const event = actions[isCondition].event;
              let [selectTitle, restData] = await conditionFunc(
                event,
                actions,
                myScreenData,
                dispatch,
                navigation,
                actions[actionIndex],
              );
              if (restData !== null) {
                return [selectTitle, restData];
              }
            }
          }
        } else if (condition.length === 2) {
          const value1 = condition[0].value;
          const value2 = condition[1].value;
          let element1;
          if (value1.contain_index === 'undefined') {
            element1 =
              myScreenData[value1.screenIndex].lastDroppedItem[value1.index];
          } else {
            element1 =
              myScreenData[value1.screenIndex].lastDroppedItem[value1.index]
                .items[value1.contain_index];
          }
          if (value2 === 'hidden') {
            if (element1.visibility === false) {
              const actionIndex = action.params.conditionIndex;
              const event = actions[isCondition].event;
              let [selectTitle, restData] = await conditionFunc(
                event,
                actions,
                myScreenData,
                dispatch,
                navigation,
                actions[actionIndex],
              );
              if (restData !== null) {
                return [selectTitle, restData];
              }
            }
          }
          if (value2 === 'visible') {
            if (element1.visibility === true) {
              const actionIndex = action.params.conditionIndex;
              const event = actions[isCondition].event;
              let [selectTitle, restData] = await conditionFunc(
                event,
                actions,
                myScreenData,
                dispatch,
                navigation,
                actions[actionIndex],
              );
              if (restData !== null) {
                return [selectTitle, restData];
              }
            }
          }
        }
      }
    }
  }
  return [null, null];
};

const conditionFunc = async (
  event,
  actions,
  myScreenData,
  dispatch,
  navigation,
  action,
) => {
  if (
    event === 'restful_get' ||
    event === 'restful_post' ||
    event === 'restful_put' ||
    event === 'restful_delete'
  ) {
    //buraya clickRestful gelecek
    //return durumları var
    const [selectTitle, restData] = await clickEventForRestful(
      actions,
      myScreenData,
      true,
    );
    return [selectTitle, restData];
  }
  if (
    event === 'width' ||
    event === 'height' ||
    event === 'visibility' ||
    event === 'top' ||
    event === 'left' ||
    event === 'backgroundColor'
  ) {
    //buraya clickCostume gelecek
    clickEventForAllComp(dispatch, actions, true, action);
    return [null, null];
  }
  if (event === 'navigate' || event === 'navigate_back') {
    clickEventForNavigate(actions, navigation, true);
    return [null, null];
  }
  if (
    event === 'logout_user' ||
    event === 'sing_user' ||
    event === 'log_user'
  ) {
    const accountData = await clickEventForAccount(actions, myScreenData, true);
    return ['account++1', accountData];
  }
};
export default clickEventForCondition;
