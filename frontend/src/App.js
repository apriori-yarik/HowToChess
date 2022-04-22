import React, { useState } from "react";
import "./App.css";
import Chessboard from "chessboardjsx";

const Chess = require("chess.js");

const App = () => {
    const [chess] = useState(
        new Chess("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
    );

    const [fen, setFen] = useState(chess.fen());

    const handleMove = (move) => {
        if (chess.move(move)) {
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");
            myHeaders.append("Access", "*/*");

            var raw = chess.fen();

            // var requestOptions = {
            //   method: "POST",
            //   headers: myHeaders,
            //   body: raw,
            // };

            // fetch("https://chess.apurn.com/nextmove", requestOptions)
            //   .then((response) => response.text())
            //   .then((result) => {
            //     chess.move(result, { sloppy: true });
            //     setFen(chess.fen());
            //   })
            //   .catch((error) => console.log("error", error));

            var body = {
                fen: raw
            };

            var requestOptions = {
                method: "POST",
                headers: myHeaders,
                body: JSON.stringify(body)
            };

            fetch("/api/Stockfish", requestOptions)
                .then((response) => response.text())
                .then((result) => {
                    chess.move(result, { sloppy: true });
                    setFen(chess.fen());
                })
                .catch((error) => console.log("error", error));

            // setTimeout(() => {
            //   const moves = chess.moves();
            //   console.log(moves);

            //   if (moves.length > 0) {
            //     //const computerMove = moves[Math.floor(Math.random() * moves.length)];
            //     chess.move("d7d5", { sloppy: true });
            //     setFen(chess.fen());
            //   }
            // }, 300);

            setFen(chess.fen());
        }
    };

    return (
        <div className="flex-center">
            <h1>Random chess</h1>
            <Chessboard
                width={400}
                position={fen}
                onDrop={(move) =>
                    handleMove({
                        from: move.sourceSquare,
                        to: move.targetSquare,
                        promotion: "q",
                    })
                }
            />
        </div>
    );
};

export default App;
