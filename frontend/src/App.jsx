import "./App.css";
import "react-toastify/dist/ReactToastify.min.css";
import LoginForm from "./components/Auth/LoginForm";
import PrivateRoute from "./components/Auth/PrivateRoute";
import { ToastContainer } from "react-toastify";
import store from "./redux/store";
import { Provider } from "react-redux";
import { Routes, Route, BrowserRouter as Router } from "react-router-dom";

function App() {
  return (
    <>
      <Provider store={store}>
        <Router>
          <Routes>
            <Route element={<PrivateRoute />}>
              <Route path="/" element={<LoginForm />} />
            </Route>
            <Route path="/login" element={<LoginForm />} />
          </Routes>
        </Router>
        <ToastContainer
          position="top-right"
          autoClose={2500}
          hideProgressBar
          newestOnTop={false}
          closeOnClick
          rtl={false}
          pauseOnFocusLoss={false}
          draggable
          pauseOnHover
          theme="light"
          transition:Bounce
        />
      </Provider>
    </>
  );
}

export default App;
