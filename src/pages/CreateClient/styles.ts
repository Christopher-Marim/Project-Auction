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
 display:flex;
 flex-direction:column;
 justify-content:center;
 align-items:center;
 width:50%;

 .groupInput{
     display: flex;
     flex-direction:column;
     margin:10px;
     width: 100%;

     label{
         font-size:18px;
     }

     input{
         padding:10px;
         border-radius:10px;
         background: white;
         border:1px rgba(5, 82, 171, 1) solid; 
         margin-top:5px;
     }
     textarea{
        border-radius:10px;
        padding:10px;
         background: white;
         border:1px rgba(5, 82, 171, 1) solid; 
         margin-top:5px;
         min-height:250px;
         max-width:100%;
     }

     button{
         padding:20px;
         border-style:none;
         border-radius:10px;
         background: rgba(0, 219, 146, 1);
         font-size:20px;
         color:white;
         cursor:pointer;

         &:hover{
            filter:brightness(.8)
         }
     }
 }
`;
