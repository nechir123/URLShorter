

import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import { useEffect, useState } from 'react';

function StatisticContainer() {
    const [data, setData] = useState(null);

    useEffect(() => {
        async function getData() {
            const response = await fetch('/url/all/');
            const data = await response.json();
            setData(data.originalUrl);
        }
        getData();
    }, []);

    console.log(data);
    return (

        <div className="App">
            <header className="App-header">
                asdasd
            </header>
        </div>
    );
}

export default StatisticContainer;