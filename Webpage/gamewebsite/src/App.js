import Navbar from './components/Navbar';
import Home from "./pages/Home";
import About from "./pages/About";
import Authors from "./pages/Authors";
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import "./App.css";

const App = () => {
  return (
    <div className="App">
      <Router>
        <Navbar />

        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/authors" element={<Authors />} />
        </Routes>

      </Router>
    </div>
  );
}

export default App;

/*
const App = () => {
  return (
    <>
      <Navbar/>
      <div className='container'>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/authors" element={<Authors />} />
          <Route path="/about" element={<About />} />
        </Routes>
      </div>
    </>
  );
}

export default App;
*/