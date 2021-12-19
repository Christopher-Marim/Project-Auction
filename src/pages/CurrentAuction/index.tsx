import { Container, Name, Wrapper, Infos, Actions, List } from "./styles";

import { useCurrent } from "../../hooks/state";
import Countdown from "react-countdown";

export function CurrentAuction() {
 
  const {currentAuction,setAuction} = useCurrent();

  return (
    <Container>
      <div className="title">
        <Name>{currentAuction?.name}</Name>
      </div>
      <Wrapper>
        <Infos>
          <img src={currentAuction?.image}></img>
          <p className="name">{currentAuction?.name}</p>  
          <p className="name">Iniciado em {currentAuction?.date}</p>
          <p className="moreInfo">{currentAuction?.motivo}</p>
          {currentAuction?.time&&currentAuction?.time!=0 ?
            <Countdown date={Date.now() + currentAuction.time} />
            :<p className="souldOut">SOULD OUT</p>
          }        
        </Infos>
        <Actions>
          <p className='entrar'>Entrar</p>
          <div className="groupBegin">
          <div className="groupInput">
          <input type='number' min={currentAuction?.priceMin}></input>
          <p>Valor minimo:{currentAuction?.priceMin}</p>
          </div>
          <button type='button'>Pagar</button>
          </div>
          <div/>
        </Actions>
        <List>
            --lista dos que entraram--
        </List>
      </Wrapper>
    </Container>
  );
}
