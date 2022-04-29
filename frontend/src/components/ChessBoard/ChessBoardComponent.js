import React, { useState } from "react";

import Chessboard from "chessboardjsx";

const Chess = require("chess.js");

const ChessBoardComponent = () => {
  const [chess] = useState(new Chess("6k1/5ppp/8/8/8/8/5PPP/R5K1 w - - 0 1"));

  const [fen, setFen] = useState(chess.fen());

  const handleMove = (move) => {
    if (chess.move(move)) {
      var myHeaders = new Headers();
      myHeaders.append("Content-Type", "application/json");
      myHeaders.append("Access", "*/*");

      var raw = chess.fen();

      var body = {
        fen: raw,
      };

      var requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: JSON.stringify(body),
      };

      fetch("/api/Stockfish", requestOptions)
        .then((response) => response.text())
        .then((result) => {
          chess.move(result, { sloppy: true });
          setFen(chess.fen());
        })
        .catch((error) => console.log("error", error));

      setFen(chess.fen());
    }
  };

  return (
    <div className="flex-center">
      <h1>Professional</h1>
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

export default ChessBoardComponent;
