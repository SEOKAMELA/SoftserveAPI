import React, {useState } from "react";
import "./Customers.css";

function Customers() {
  const [customers, setCustomers] = useState([]);


  function getCustomers(){
    const urls = ("https://localhost:7003/customer");
    fetch(urls,{
      method: 'GET'
    })
    .then(response => response.json)
    .then(results => {
      console.log(results);
      setCustomers(results);
    })
    .catch((error) => {
      console.log(error)
      alert(error);
    })
  }

  return (
    <div className="customer">
      <div className="customer-container">
        <h1 className="customer-tile">List of customer</h1>
        <a
          href="/"
          className="btn btn-primary btn-lg active"
          role="button"
          aria-pressed="true"
          onClick={getCustomers}
        >
          create customer
        </a>
      </div>
      <br />
      <table className="table table-striped">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Name</th>
            <th scope="col">Surname</th>
            <th scope="col">Usename</th>
            <th scope="col">email</th>
            <th scope="col">Date of birth</th>
            <th scope="col">Age</th>
            <th scope="col">Date created</th>
            <th scope="col">Usename</th>

          </tr>
        </thead>
        <tbody>
            {customers.map((customers) => (
                <tr>
                <th scope="row">1</th>
                {/* <td>{customers.}</td> */}
                <td>{customers.firstName}</td>
                {/* <td>{customers.emailAddress}</td> */}
                </tr>
            ))}
            {/* <button type="button" className="btn btn-primary" >Update</button>
            <button type="button" className="btn btn-danger">Delete</button> */}
          

        </tbody>
      </table>
    </div>
  );
}

export default Customers;
