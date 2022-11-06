import axios from "axios";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuthContext } from "../hooks/authContext";
import { Space, Table } from "antd";
import "../components/css/button.css";

const { Column, ColumnGroup } = Table;

function Posts() {
  const [person, SetPerson] = useState([]);
  const { isAuthenticated } = useAuthContext();
  const navigate = useNavigate();

  const handleUpdate = (id) => {
    navigate(`/update/${id}`);
  };

  const handleDetail = (id) => {
    navigate(`/detail/${id}`);
  };

  const handleAdd = () => {
    navigate("/create");
  };

  const handleDelete = (id) => {
    var checkingDelete = window.confirm(
      `Do you want to delete person with id: ${id}`
    );
    if (checkingDelete) {
      axios({
        method: "delete",
        url: `https://localhost:7228/Task/list-deletion?index=${id}`,
      })
        .then((response) => {
          console.log(response);
        })
        .catch((error) => {
          console.log(error);
        });

      window.location.reload();
    }
  };

  useEffect(() => {
    axios({
      method: "GET",
      url: "https://localhost:7228/Task/all-list",
      data: null,
    })
      .then((data) => {
        SetPerson(data.data);
        console.log(data.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  return (
    <div>
      <h1>Post page</h1>
      {isAuthenticated === true && (
        <div>
          <div>
            <button class="createButton" onClick={handleAdd}>go to create post</button>
          </div>

          <div>
            <Table dataSource={person} pagination={{ pageSize: 10 }} key="1">
              <Column title="Id" dataIndex="uniqueId" key={person.uniqueId} />
              <ColumnGroup title="Name">
                <Column
                  title="First Name"
                  dataIndex="firstName"
                  key={person.firstName}
                />
                <Column
                  title="Last Name"
                  dataIndex="lastName"
                  key={person.lastName}
                />
              </ColumnGroup>
              <Column title="Gender" dataIndex="gender" key={person.gender} />

              <Column
                title="Action"
                key="action"
                render={(_, record) => (
                  <Space size="middle">
                    <button
                      class="updateButton"
                      onClick={() => handleUpdate(record.uniqueId)}
                    >
                      Edit {record.firstName}
                    </button>
                    <button
                      class="detailButton"
                      onClick={() => handleDetail(record.uniqueId)}
                    >
                      Detail
                    </button>
                    <button
                      class="deleteButton"
                      value={record.uniqueId}
                      onClick={() => handleDelete(record.uniqueId)}
                    >
                      Delete
                    </button>
                  </Space>
                )}
              />
            </Table>
          </div>
        </div>
      )}
    </div>
  );
}

export default Posts;
