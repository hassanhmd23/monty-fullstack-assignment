import "./App.css";
import "react-toastify/dist/ReactToastify.min.css";
import PrivateRoute from "./components/Auth/PrivateRoute";
import { ToastContainer } from "react-toastify";
import store from "./redux/store";
import { Provider } from "react-redux";
import { Routes, Route, BrowserRouter as Router } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import DashboardPage from "./pages/DashboardPage";
import UsersPage from "./pages/UsersPage";
import UserPage from "./components/Users/UserPage";

function App() {
  return (
    <>
      <Provider store={store}>
        <Router>
          <Routes>
            <Route element={<PrivateRoute />}>
              <Route path="/" element={<DashboardPage />} />
              <Route path="/users" element={<UsersPage />} />
              <Route path="/users/:id" element={<UserPage />} />
            </Route>
            <Route path="/login" element={<LoginPage />} />
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
