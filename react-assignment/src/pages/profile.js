import { useAuthContext } from "../hooks/authContext";
import { Link } from "react-router-dom";

function Profile() {
  const { isAuthenticated } = useAuthContext();
  
  return (
    <div>
      {isAuthenticated === false && (
        <Link to="/login" style={{ padding: "10px" }}>
          Login
        </Link>
      )}
      {isAuthenticated === true && (
        <h1>Profile Page</h1>
      )}
    </div>
  );
}

export default Profile;
