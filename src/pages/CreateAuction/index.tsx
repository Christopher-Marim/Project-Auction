import { Container, Name, Wrapper } from "./styles";
export function CreateAuction() {
  return (
    <Container>
      <div className="title">
        <Name>Criar Leilão</Name>
      </div>
      <Wrapper>
          <div className="groupInput">
              <label>Nome</label>
              <input></input>
          </div>
          <div className="groupInput">
              <label>Preço Minimo</label>
              <input></input>
          </div>
          <div className="groupInput">
              <label>Data Fim</label>
              <input type="date"></input>
          </div>
          <div className="groupInput">
              <label>Sobre</label>
              <textarea></textarea>
          </div>       
          <div className="groupInput">
              <label>Imagem</label>
              <input type="file"></input>
          </div>
          <div className="groupInput">
              <button type="button">Criar</button>
          </div>
      </Wrapper>
    </Container>
  );
}
