import styled from "styled-components";

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  height: 100vh;
  padding: 50px 100px;
  background: #e3e9ff;
  align-items: center;

  .title {
    display: flex;
    align-items: center;
    max-width: 600px;
  }
`;

export const Name = styled.h1`
  font-size: 62px;
  background: linear-gradient(
    90deg,
    rgba(5, 82, 171, 1) 0%,
    rgba(0, 219, 146, 1) 100%
  );
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
`;

export const Wrapper = styled.div`
  display: flex;
  flex-direction:row;
  justify-content: space-between;
  background: white;
  border-radius: 10px;
  padding: 10px;
  width:70%;
  height: 100%;

`;
export const Infos = styled.div`
  display: flex;
  align-items: center;
  flex-direction:column;
  height: 100%;
  padding:10px;
  background: white;
  border-right:1.5px #e3e3e3 solid;
  width:100%;

  img{
    width:150px;
    height:150px;
    border-radius:50%;
    object-fit:cover;
    margin:10px;
    border: double 2px transparent;
  border-radius: 50%;
  background-image: linear-gradient(white, white), radial-gradient(circle at top left, rgba(5, 82, 171, 1), rgba(0, 219, 146, 1));
  background-origin: border-box;
  background-clip: content-box, border-box;
  }

  .name{
    font-size:18px;
    color:rgba(5, 82, 171, 1);
  }
  
  .souldOut{
    font-size:30px;
    color:#e80000;
  }
  .moreInfo{
    font-size:18px;
    color:#777777;
    text-align: center;
    margin:30px;
  }
  span{
    margin-top:70px;
    font-size:30px;
    color:rgba(0, 219, 146, 1);
  }
  
`;
export const Actions = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-direction:column;
  background: white;
  width:100%;
  border-right:1.5px #e3e3e3 solid;

  .entrar{
    font-size:25px;
    color:rgba(5, 82, 171, 1);
  }
  .groupBegin{
    display: flex;
  justify-content: center;
  flex-direction:column;
  align-items: center;
    width:100%;
  }
  .groupInput{
    display: flex;
  justify-content: center;
  flex-direction:column;
  align-items: center;
    width:100%;
    p{
      margin:5px;
      width:80%;
      color:#cdcdcd;
    }
  }

  input{
  width:80%;
  font-size:18px;
  border: double 2px rgba(5, 82, 171, 1);
  padding:20px;
  border-radius: 10px;
  }
  
  button{
  margin-top:20px;
  color:rgba(0, 219, 146, 1);
  font-size:18px;
  width:80%;
  padding:20px;
  background: white;
  border:2px rgba(0, 219, 146, 1) solid;
  border-radius: 10px;
  cursor:pointer;
  &:hover{
    background: rgba(0, 219, 146, 1);
    color:white;
  }
  }
`;
export const List = styled.div`
  display: flex;
  flex-direction:column;
  justify-content: center;
  align-items: center;
  background: white;
  width:100%;
  
`;
