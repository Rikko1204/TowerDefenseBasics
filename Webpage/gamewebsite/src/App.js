import Navbar from './Navbar';
import Home from "./pages/Home";
import Authors from "./pages/Authors";
import About from "./pages/About";
import {Route, Routes} from 'react-router-dom';

const App = () => {
  /*
  let Component;
  switch(window.location.pathname) {
    case "/":
     Component = Home
      break;
    case "/authors":
     Component = Authors
      break;
    case "/about":
     Component = About
      break;
  }
*/
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
