import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import HomeContainer from "./containers/HomeContainer";
import StatisticContainer from "./containers/StatisticContainer";
import Redirect from "./Redirect";
import "devextreme/dist/css/dx.light.css";
function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomeContainer />}></Route>
        <Route path="/:shortenUrl" element={<Redirect />}></Route>
        <Route path="/statistic/:code" element={<StatisticContainer />}></Route>
      </Routes>
    </Router>
  );
}

export default App;
