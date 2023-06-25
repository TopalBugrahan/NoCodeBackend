const clickEventForNavigate = (actions, navigation, isComeingCondition) => {
  for (const action of actions) {
    const isCondition = action.params.conditionIndex;
    if (isCondition === null || isComeingCondition === true) {
      if (action.event === 'navigate') {
        const screenName = action.route;
        navigation.navigate(screenName);
      }
      if (action.event === 'navigate_back') {
        navigation.goBack();
      }
    }
  }
};
export default clickEventForNavigate;
