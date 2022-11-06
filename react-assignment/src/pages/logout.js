import { useNavigate } from "react-router-dom";
import { useAuthContext } from "../hooks/authContext";
import "../components/css/button.css";

function Logout() {
    let navigate = useNavigate();
    const {setIsAuthenticated} = useAuthContext();

    const logout = () => {
        setIsAuthenticated(false);
        navigate("/")
    }
    return <div>
        <button className="logoutButton" onClick={logout}>Logout</button>
    </div>
}

export default Logout;