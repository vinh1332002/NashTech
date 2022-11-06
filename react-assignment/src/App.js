import React from "react";
import { Routes, Route, Link } from "react-router-dom";
import Profile from "./pages/profile";
import Login from "./pages/login";
import Posts from "./pages/posts";
import LayoutPage from "./components/layout";
import CreatePost from "./pages/createPost";
import UpdatePost from "./pages/updatePost";
import RequiredAuth from "./components/requireAuth";
import AuthProvider from "./hooks/authContext";
import Home from "./pages/home";
import Logout from "./pages/logout";
import DetailPost from "./pages/detailPost";

function App() {
  return (
    <AuthProvider>

      <Routes>
        <Route element={<LayoutPage />}>
          <Route path="/post" element={<Posts />} />
          <Route path="/login" element={<Login />} />
          <Route
            path="/profile"
            element={
              <RequiredAuth>
                <Profile />
              </RequiredAuth>
            }
          />
          <Route path="/" element={<Home/>}/>
          <Route path="/logout" element={<Logout/>}/>
          <Route path="/create" element={<CreatePost />} />
          <Route path="/detail/:id" element={<DetailPost/>} />
          <Route path="/update/:id" element={<UpdatePost />} />
        </Route>
      </Routes>
    </AuthProvider>
  );
}

export default App;
