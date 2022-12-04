import './App.css';

function App() {

  //fectcusomers
  async function fectCustomers() {
    Fetch("https://localhost:7066/Customer")
    .then(res => res.json())
    .then(
      (result) => {
        this.setState({
          employees: result
        });
      }
    );
  }
  return (
    <div className="App">
          <header className="App-header">
            <h2>
              Add new Customer
            </h2>
          <form>
          <label>
            Name:
            <input type="text" name="name" />
        </label>
        <label>
            Surnme:
            <input type="text" name="name" />
        </label>      <label>
            Username:
            <input type="text" name="name" />
        </label>      <label>
            Email:
            <input type="text" name="name" />
        </label>
        <br/>
        <input type="submit" value="Submit" />
    </form>
      </header>
    </div>
  );
}

export default App;
