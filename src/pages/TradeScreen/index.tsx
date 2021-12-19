import { Container, Name, List, Item } from "./styles";
import Countdown from "react-countdown";
export function TradeScreen() {
  const array = [
    {
      id: 1,
      image:
        "https://s2.glbimg.com/mYgwlPa7vtIiUk6kROUxJUi2yyo=/0x0:620x413/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_cf9d035bf26b4646b105bd958f32089d/internal_photos/bs/2020/a/4/Ik8J1fQYirf6wYRvRJ8Q/2020-03-20-novo-tracker-1.jpg",
      name: "Carro de alta categoria",
      price: "R$25.000,00",
      date: "18/12/2021",
      time:500000
    },
    {
        id:2,
        image:
          "https://s2.glbimg.com/mYgwlPa7vtIiUk6kROUxJUi2yyo=/0x0:620x413/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_cf9d035bf26b4646b105bd958f32089d/internal_photos/bs/2020/a/4/Ik8J1fQYirf6wYRvRJ8Q/2020-03-20-novo-tracker-1.jpg",
        name: "Carro de alta categoria",
        price: "R$25.000,00",
        date: "18/12/2021",
        time:200000
      },
      {
        id:3,
        image:
          "https://s2.glbimg.com/mYgwlPa7vtIiUk6kROUxJUi2yyo=/0x0:620x413/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_cf9d035bf26b4646b105bd958f32089d/internal_photos/bs/2020/a/4/Ik8J1fQYirf6wYRvRJ8Q/2020-03-20-novo-tracker-1.jpg",
        name: "Carro de alta categoria",
        price: "R$25.000,00",
        date: "18/12/2021",
        time:100000
      },
  ];

  return (
    <Container>
      <div className="title">
        <Name>Lista de Leilões</Name>
      </div>
      <List>
        {array.map((item) => (
          <Item key={item.id}>
            <img src={item.image}></img>
            <div className="infos">
              <p>
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
