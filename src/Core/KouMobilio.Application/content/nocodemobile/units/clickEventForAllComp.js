import {
  changeWidth,
  changeVisibility,
  changeHeight,
  changeTop,
  changeLeft,
  changeBackgroundColor,
} from '../redux/Slice';
const clickEventForAllComp = (
  dispatch,
  actions,
  isComeingCondition,
  action,
) => {
  if (isComeingCondition) {
    if (action.event === 'width') {
      dispatch(
        changeWidth({
          data: action.params.selectCostum,
          width: action.params.width,
        }),
      );
    } else if (action.event === 'visibility') {
      dispatch(changeVisibility({data: action.params.selectCostum}));
    } else if (action.event === 'height') {
      dispatch(
        changeHeight({
          data: action.params.selectCostum,
          height: action.params.height,
        }),
      );
    } else if (action.event === 'top') {
      dispatch(
        changeTop({
          data: action.params.selectCostum,
          top: action.params.top,
        }),
      );
    } else if (action.event === 'left') {
      dispatch(
        changeLeft({
          data: action.params.selectCostum,
          left: action.params.left,
        }),
      );
    } else if (action.event === 'backgroundColor') {
      dispatch(
        changeBackgroundColor({
          data: action.params.selectCostum,
          color: action.params.backgroundColor,
        }),
      );
    }
  } else {
    for (const action of actions) {
      const isCondition = action.params.conditionIndex;
      if (isCondition === null) {
        if (action.event === 'width') {
          dispatch(
            changeWidth({
              data: action.params.selectCostum,
              width: action.params.width,
            }),
          );
        } else if (action.event === 'visibility') {
          dispatch(changeVisibility({data: action.params.selectCostum}));
        } else if (action.event === 'height') {
          dispatch(
            changeHeight({
              data: action.params.selectCostum,
              height: action.params.height,
            }),
          );
        } else if (action.event === 'top') {
          dispatch(
            changeTop({
              data: action.params.selectCostum,
              top: action.params.top,
            }),
          );
        } else if (action.event === 'left') {
          dispatch(
            changeLeft({
              data: action.params.selectCostum,
              left: action.params.left,
            }),
          );
        } else if (action.event === 'backgroundColor') {
          dispatch(
            changeBackgroundColor({
              data: action.params.selectCostum,
              color: action.params.backgroundColor,
            }),
          );
        }
      }
    }
  }
};

export default clickEventForAllComp;
