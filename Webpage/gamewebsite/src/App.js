import Navbar from './components/Navbar';
import Home from "./pages/Home";
import About from "./pages/About";
import Play from "./pages/Play";
import Authors from "./pages/Authors";
import Footer from "./components/Footer";
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
          <Route path="/play" element={<Play />} />
          <Route path="/authors" element={<Authors />} />
        </Routes>

        <Footer />
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