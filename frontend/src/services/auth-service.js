import axios from "axios";
const API_URL = "https://localhost:7181/api/auth/";
class AuthService {
  login(username, password) {
    return axios
      .post(API_URL + "login", {
        username,
        password,
      })
      .then((response) => {
        if (response.data) {
          sessionStorage.setItem("user", JSON.stringify(response.data));
        }
        return response.data;
      });
  }
  logout() {
    sessionStorage.removeItem("user");
  }
  register(fullName, email, password, rating) {
    return axios.post(API_URL + "register", {
      fullName,
      email,
      password,
      rating,
    });
  }
  getCurrentUser() {
    return JSON.parse(sessionStorage.getItem("user"));
  }
}
export default new AuthService();
