
import { useEffect, useState } from "react";
function Redirect() {
  var loc = document.location;

  useEffect(() => {
    async function getData() {
        const response = await fetch('/url/?shortenUrl=' + loc.href);
        const data = await response.json();      
         window.location.replace(data.originalUrl);
    }
    getData();
  }, []);

  return <p></p>;
}

export default Redirect;