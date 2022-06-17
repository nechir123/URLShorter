
import { useEffect, useState } from "react";


function Redirect() {
  const [destination, setDestination] = useState<null | string>(null);
  const [error, setError] = useState();
  var loc = document.location;

  useEffect(() => {
    async function getData() {
        const response = await fetch('/url/?shortenUrl=' + loc.href);
        const data = await response.json();
        setDestination(data.originalUrl);
    }
    getData();
  }, [loc.href]);

  useEffect(() => {
    if (destination) {
      window.location.replace(destination);
    }
  }, [destination]);

  if (!destination && !error) {
    return (
        <div>asdasdas</div>
    );
  }

  return <p>{error && JSON.stringify(error)}</p>;
}

export default Redirect;