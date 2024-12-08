import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import * as loginActions from "../../redux/actions/loginActions";
import { useNavigate } from "react-router-dom";
import "./Loginstyle.css";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const dispatch = useDispatch();
  const loginData = useSelector((state) => state.login);
  const navigate = useNavigate();
  const { loading, error } = loginData;

  const handleSubmit = (e) => {
    e.preventDefault();
    dispatch(loginActions.handleLogin({ email, password }));
  };

  useEffect(() => {
    if (loginData.user) {
      setTimeout(() => {
        navigate("/");
        dispatch(loginActions.resetRedirecting());
      }, 1500);
    }
  }, [loginData.user, navigate, dispatch]);

  if (loginData.isRedirecting) {
    return (
      <div className="loading-container">
        <img
          src="/Images/hylogoanimation.png"
          alt="company-logo"
          className="logo-animation"
        ></img>
      </div>
    );
  }

  return (
    <div className="box-1">
      <div className="white-panel">
        <img
          src="/Images/HYlogo.jpg"
          alt="Company-Logo"
          className="panel-image"
        />
        <form className="form-1" onSubmit={handleSubmit}>
          <label className="login-label">E-posta</label>
          <input
            type="email"
            className={`input-1 ${
              error && error.includes("email") ? "input-error" : ""
            }`} // Eğer email ile ilgili bir hata varsa sınıf ekliyoruz
            name="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
          {error === "Kullanıcı mevcut değil" && (
            <p className="error-text">Kullanıcı mevcut değil</p>
          )}

          <label className="login-label" id="login-label-password">
            Parola
          </label>
          <input
            type="password"
            className={`input-1 ${
              error && error.includes("Şifre") ? "input-error" : ""
            }`} // Şifre hatası varsa sınıf ekliyoruz
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
            {error === "Şifre Yanlış" && (
              <p className="error-text">Şifre Yanlış</p>
            )}

          <button type="submit" className="btn-1" disabled={loading}>
            {loading ? "Yükleniyor..." : "Giriş Yap"}
          </button>
          {error && <p className="error-text">{error}</p>}

          <a href="https://www.google.com.tr" id="link-1">
            Şifrenizi mi unuttunuz?
          </a>
        </form>
      </div>
    </div>
  );
};

export default Login;
