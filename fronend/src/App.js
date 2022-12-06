import './App.css';
import CreateCustomer from './views/create/CreateCustomer';
import Customers from './views/customers/Customers';

function App() {

  return (
    <div className="App">
      <header className="App-header">
        <Customers />
        <CreateCustomer />
      </header>
    </div>
  );
}

export default App;
