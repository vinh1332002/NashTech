import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import "../components/css/button.css";

function DetailPost() {
  const navigate = useNavigate();

  const handleBackToList = () => {
    navigate(`/post`);
  };

  const { id } = useParams();

  const [data, setData] = useState([]);

  useEffect(() => {
    axios({
      method: "GET",
      url: `https://localhost:7228/Task/one-list?index=${id}`,
      data: null,
    })
      .then((response) => {
        console.log(response.data);
        setData(response.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  return (
    <div>
      <h1>Detail page</h1>
      <div>
        <div>
          <label>
            Id:
            <p>{data.uniqueId}</p>
          </label>
        </div>
        <div>
          <label>
            First Name:
            <p>{data.firstName}</p>
          </label>
        </div>
        <div>
          <label>
            Last Name:
            <p>{data.lastName}</p>
          </label>
        </div>
        <div>
          <label>
            Gender:
            <p>{data.gender}</p>
          </label>
        </div>
        <div>
          <label>
            Date Of Birth:
            <p>{data.dateOfBirth}</p>
          </label>
        </div>
        <div>
          <label>
            BirthPlace:
            <p>{data.birthPlace}</p>
          </label>
        </div>
        <div>
          <button class="backButton" onClick={handleBackToList} variant="secondary" type="reset">
            Back to Post Page
          </button>
        </div>
      </div>
    </div>
  );
}

export default DetailPost;
