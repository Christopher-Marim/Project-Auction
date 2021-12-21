import { Container, Name, List, Item } from "./styles";
import Countdown from "react-countdown";
import { useHistory } from 'react-router';
import { useCurrent } from "../../hooks/state";

interface Auction {
  id: string;
  name: string;
  image: string;
  price: string;
  priceMin:number;
  date:string;
  about?:string;
  time:number;
}

export function TradeScreen() {
  const history = useHistory();
  const {setAuction} = useCurrent()
  const array = [
    {
      id: '1',
      image:
        "https://s2.glbimg.com/mYgwlPa7vtIiUk6kROUxJUi2yyo=/0x0:620x413/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_cf9d035bf26b4646b105bd958f32089d/internal_photos/bs/2020/a/4/Ik8J1fQYirf6wYRvRJ8Q/2020-03-20-novo-tracker-1.jpg",
      name: "Carro A",
      price: "R$25.000,00",
      date: "18/12/2021",
      about:'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Pariatur nobis aliquam non a, consectetur, nesciunt officia iure nisi adipisci quae beatae saepe sed sunt odit, nulla quo suscipit inventore veniam? ',
      time:500000,
      priceMin:10
    },
    {
        id:'2',
        image:
          "https://s2.glbimg.com/mYgwlPa7vtIiUk6kROUxJUi2yyo=/0x0:620x413/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_cf9d035bf26b4646b105bd958f32089d/internal_photos/bs/2020/a/4/Ik8J1fQYirf6wYRvRJ8Q/2020-03-20-novo-tracker-1.jpg",
        name: "Carro B",
        price: "R$25.000,00",
        date: "18/12/2021",
        about:'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Pariatur nobis aliquam non a, consectetur, nesciunt officia iure nisi adipisci quae beatae saepe sed sunt odit, nulla quo suscipit inventore veniam? ',
        time:200000,
        priceMin:10
      },
      {
        id:'3',
        image:
          "https://s2.glbimg.com/mYgwlPa7vtIiUk6kROUxJUi2yyo=/0x0:620x413/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_cf9d035bf26b4646b105bd958f32089d/internal_photos/bs/2020/a/4/Ik8J1fQYirf6wYRvRJ8Q/2020-03-20-novo-tracker-1.jpg",
        name: "Carro C",
        price: "R$25.000,00",
        date: "18/12/2021",
        time:100000,
        priceMin:10
      },
      {
        id:'4',
        image:
          "https://s2.glbimg.com/mYgwlPa7vtIiUk6kROUxJUi2yyo=/0x0:620x413/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_cf9d035bf26b4646b105bd958f32089d/internal_photos/bs/2020/a/4/Ik8J1fQYirf6wYRvRJ8Q/2020-03-20-novo-tracker-1.jpg",
        name: "Carro D",
        price: "R$26.000,00",
        date: "18/12/2021",
        time:100000,
        priceMin:10
      },
  ];

  function handleItemClick(item:Auction){
    setAuction(item)
    history.push('currentAuction')
  }

  return (
    <Container>
      <div className="title">
        <Name>Lista de Leilões</Name>
      </div>
      <List>
        {array.map((item) => (
          <Item key={item.id} onClick={()=>{handleItemClick(item)}}>
            <img src={item.image}></img>
            <div className="infos">
              <p className="name">
                <strong>{item.name}</strong>
              </p>
              <p>Preço: {item.price}</p>
              <p>Data: {item.date}</p>
            </div>
            <div className="timer">
              <Countdown date={Date.now() + item.time} />
            </div>
          </Item>
        ))}
      </List>
    </Container>
  );
}
