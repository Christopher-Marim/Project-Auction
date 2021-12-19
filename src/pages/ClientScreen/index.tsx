import './styles.scss';

import { useHistory } from 'react-router';

export function ClientScreen() {
  const history = useHistory();
  return (
    <div id='containerClient'>
      <section className="bdg-sect" id="i7x5k">
        <h1 className="heading" id="i24kn">
          Leilão
        </h1>
        <p className="paragraph" id="isz2w">
          Insira suas informações para entrar em leilões vigentes
        </p>
      </section>
      <form className="form" id="i972">
        <div className="form-group">
          <label className="label" id="if7h">
            Nome
          </label>
          <input
            placeholder="Digite seu nome"
            type="text"
            required
            className="input"
            id="i20j"
          />
        </div>
        <div className="form-group">
          <label className="label">Email</label>
          <input
            type="email"
            placeholder="Digite seu email"
            className="input"
            id="isuy"
          />
        </div>
        <div className="form-group" id="ij9cj">
          <label className="label" id="inkxr">
            Genero
          </label>
          <input type="checkbox" value="M" className="checkbox" />
          <label className="checkbox-label">M</label>
          <input type="checkbox" value="F" className="checkbox" />
          <label className="checkbox-label">F</label>
        </div>
        <div className="form-group">
          <label className="label" id="ideth">
            Chave Publica
          </label>
          <textarea className="textarea" id="irl6i"></textarea>
        </div>
        <div className="form-group">
          <button type="button" className="button" id="i0v76" onClick={()=>{history.push('/pages/auctions')}}>
            Enviar
          </button>
        </div>
      </form>
    </div>
  );
}
