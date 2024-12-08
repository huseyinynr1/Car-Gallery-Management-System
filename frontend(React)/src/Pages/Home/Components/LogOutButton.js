import { useDispatch } from "react-redux"
import { useNavigate } from "react-router-dom";
import * as loginActions from "../../../redux/actions/loginActions";

const LogOutButton= () => {
    
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const handleLogoutClick = () => {
        dispatch(loginActions.handleLogout());
        navigate('/login');
    }
        
    return(
        <div>
            <button onClick={handleLogoutClick}>Çıkış Yap</button>
        </div>
    );
}

export default LogOutButton;