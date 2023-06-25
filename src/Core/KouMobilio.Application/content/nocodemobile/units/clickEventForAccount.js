const clickEventForAccount = async (
  actions,
  myScreenData,
  isComeingCondition,
) => {
  for (const action of actions) {
    const isCondition = action.params.conditionIndex;
    if (isCondition === null || isComeingCondition === true) {
      if (action.event === 'sing_user') {
        const uri = 'https://dummyjson.com/auth/login';
        const usernameObj = JSON.parse(action.params.selectEmail);
        const passwordObj = JSON.parse(action.params.selectPassport);
        let usernameValue =
          myScreenData[usernameObj.screenIndex].lastDroppedItem[
            usernameObj.index
          ].text;
        if (usernameObj.contain_index !== 'undefined') {
          usernameValue =
            myScreenData[usernameObj.screenIndex].lastDroppedItem[
              usernameObj.index
            ].items[usernameObj.contain_index].text;
        }
        let passwordValue =
          myScreenData[passwordObj.screenIndex].lastDroppedItem[
            passwordObj.index
          ].text;
        if (passwordObj.contain_index !== 'undefined') {
          passwordValue =
            myScreenData[passwordObj.screenIndex].lastDroppedItem[
              passwordObj.index
            ].items[passwordObj.contain_index].text;
        }
        const settings = {
          method: 'POST',
          body: JSON.stringify({
            username: usernameValue,
            password: passwordValue,
          }),
          headers: {
            'Content-type': 'application/json; charset=UTF-8',
          },
        };
        try {
          const fetchResponse = await fetch(uri, settings);
          const data = await fetchResponse.json();
          if (data.message !== undefined) {
            return false;
          } else {
            return data;
          }
        } catch (error) {
          return 'error';
        }
      } else if (action.event === 'log_user') {
        const uri = 'https://dummyjson.com/auth/login';
        const usernameObj = JSON.parse(action.params.selectEmail);
        const passwordObj = JSON.parse(action.params.selectPassport);
        let usernameValue =
          myScreenData[usernameObj.screenIndex].lastDroppedItem[
            usernameObj.index
          ].text;
        if (usernameObj.contain_index !== 'undefined') {
          usernameValue =
            myScreenData[usernameObj.screenIndex].lastDroppedItem[
              usernameObj.index
            ].items[usernameObj.contain_index].text;
        }
        let passwordValue =
          myScreenData[passwordObj.screenIndex].lastDroppedItem[
            passwordObj.index
          ].text;
        if (passwordObj.contain_index !== 'undefined') {
          passwordValue =
            myScreenData[passwordObj.screenIndex].lastDroppedItem[
              passwordObj.index
            ].items[passwordObj.contain_index].text;
        }
        const settings = {
          method: 'POST',
          body: JSON.stringify({
            username: usernameValue,
            password: passwordValue,
          }),
          headers: {
            'Content-type': 'application/json; charset=UTF-8',
          },
        };
        try {
          const fetchResponse = await fetch(uri, settings);
          const data = await fetchResponse.json();
          if (data.message !== undefined) {
            return false;
          } else {
            return data;
          }
        } catch (error) {
          return 'error';
        }
      } else if (action.event === 'logout_user') {
        //güncel api yok
        const uri = '';
        const settings = {
          method: 'DELETE',
        };
        try {
          const fetchResponse = await fetch(uri, settings);
          const data = await fetchResponse.json();
          if (data.message !== undefined) {
            return false;
          } else {
            return data;
          }
        } catch (error) {
          return 'error';
        }
      }
    }
  }
  return true;
};
export default clickEventForAccount;
