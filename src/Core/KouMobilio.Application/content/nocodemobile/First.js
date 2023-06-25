import {Provider} from 'react-redux';
import App from './App';
import store from './redux/Store';
export default () => {
  return (
    <Provider store={store}>
      <App />
    </Provider>
  );
};
