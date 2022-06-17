

import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import { useState } from 'react';
import axios from 'axios';
import { SERVER_ENDPOINT } from "../config";

function HomeContainer() {
    const [longUrl, setLongUrl] = useState('');
    const [shortUrl, setShortUrl] = useState('');
    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setLongUrl(event.target.value);
    };

    async function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        setShortUrl('');
        const response = await fetch('/url', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
                // 'Content-Type': 'application/x-www-form-urlencoded',
              },
              body: JSON.stringify({"originalUrl": longUrl})
        });
        const data = await response.json();
        setShortUrl(data.shortenUrl);
    }

    return (

        <div className="App">
            <header className="App-header">
            <form onSubmit={handleSubmit}>
                <Box
                    component="form"
                    sx={{
                        '& > :not(style)': { m: 1, width: '25ch' },
                    }}
                    noValidate
                    autoComplete="off"
                >
                    <TextField
                        id="outlined-name"
                        label="Long Url"
                        value={longUrl}
                        onChange={handleChange}
                    />
                </Box>
                <Button  type="submit"
                >
                    Click me
                </Button>
                </form>
                {shortUrl && (
                    <a href={`${shortUrl}`}>
                        {shortUrl}
                    </a>
                )}
            </header>
        </div>
    );
}

export default HomeContainer;