import App from "../../App";
import games from "../constants/History";

const History = () => {
  return (
    <div className="flex-center mb-3">
      {games.length === 0 && <h3>Games haven't been played yet.</h3>}
    </div>
  );
};

export default History;
