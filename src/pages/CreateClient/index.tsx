import { useHistory } from "react-router-dom";
import { Container, Name, Wrapper } from "./styles";
export function CreateClient() {
  const history = useHistory();
  return (
    <Container>
      <div className="title">
        <Name>Novo Usuario</Name>
      </div>
      <Wrapper>
          <div className="groupInput">
              <label>Nome</label>
              <input></input>
          </div>
          <div className="groupInput">
              <label>Email</label>
              <input type="email"></input>
          </div>
          <div className="groupInput">
              <label>Ano em que nasceu</label>
              <input type="date"></input>
          </div>         
          <div className="groupInput">
              <label>Chave Publica</label>
              <textarea></textarea>
          </div>       
          <div className="groupInput">
              <button type="button" onClick={()=>history.push('/pages/auctions')}>Entrar</button>
          </div>
      </Wrapper>
    </Container>
  );
}
