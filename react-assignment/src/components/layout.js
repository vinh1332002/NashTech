import { Link, Outlet } from "react-router-dom";
import { Layout, Menu } from "antd";
import { useAuthContext } from "../hooks/authContext";

const { Header, Content, Footer } = Layout;

function LayoutPage() {
  const { isAuthenticated } = useAuthContext();
  return (
    <div>
      <Layout className="layout">
        <Header>
          <div className="logo" />
          <Menu theme="dark" mode="horizontal" defaultSelectedKeys={["1"]} >
            <Menu.Item key="1">
              <Link to="/" style={{ padding: "10px" }}>
                Home
              </Link>
            </Menu.Item>
            <Menu.Item key="2">
              <Link to="/post" style={{ padding: "10px" }}>
                Posts
              </Link>
            </Menu.Item>
            <Menu.Item key="3">
              <Link to="/profile" style={{ padding: "10px" }}>
                Profile
              </Link>
            </Menu.Item>
            <Menu.Item key="4">
              {isAuthenticated === false && (
                <Link to="/login" style={{ padding: "10px" }}>
                  Login
                </Link>
              )}
              {isAuthenticated === true && (
                <Link to="/logout" style={{ padding: "10px" }}>
                  Logout
                </Link>
              )}
            </Menu.Item>
          </Menu>
        </Header>
        <Content
          style={{
            padding: "0 50px",
          }}
        >
          <div className="site-layout-content">
            <h1>Welcome to React Router!</h1>
            <Outlet />
          </div>
        </Content>
        <Footer
          style={{
            textAlign: "center",
          }}
        >
          Ant Design ©2018 Created by Ant UED
        </Footer>
      </Layout>
    </div>
  );
}
export default LayoutPage;
