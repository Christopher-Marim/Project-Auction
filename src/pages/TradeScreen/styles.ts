import styled  from 'styled-components'

export const Container = styled.div`
display:flex;
flex-direction:column;
height:100vh;
padding:50px 100px;
background:#e3e9ff;
align-items:center;

.title {
    display: flex;
    align-items: center;
    max-width: 600px;
  }

`

export const Name = styled.h1`
font-size: 62px;
  background: linear-gradient(90deg, rgba(5,82,171,1) 0%, rgba(0,219,146,1) 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
`


export const List = styled.div`
display:flex;
height:700px;
width:70%;
border-radius:10px;
flex-direction:column-reverse;
background:transparent;
padding:10px;
overflow-x:hidden;

::-webkit-scrollbar {
  width: 10px;
}
 
/* Handle */
::-webkit-scrollbar-thumb {
  background:linear-gradient( rgba(5,82,171,1) , rgba(0,219,146,1) );
  border-radius: 10px;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: rgba(0,219,146,1); 
}
`
export const Item = styled.div`
display:flex;
cursor:pointer;
margin:10px;
justify-content:space-between;
align-items:center;
padding:20px;
width:100%;
height:150px;
background: white;
border-radius:10px;
box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
transition: ease-in-out 400ms;

&:hover{
    box-shadow: rgba(18, 26, 64, 0.30) 0px 2px 4px 0px, rgba(18, 26, 64, 0.30) 0px 2px 16px 0px;
}

.infos{
    width: 100%;
    margin:0px 40px;

    .name{
      color:rgba(5,82,171,1);
    }
}

.timer{
    height: 100%;
    display: flex;
    margin:0 20px;
    align-items:center;

    span{
        font-size:25px;
        color:#cdcdcd
    }
}

img{
    width:125px;
    height:125px;
    border-radius:50%;
    object-fit:cover;
    border: double 2px transparent;
  border-radius: 50%;
  background-image: linear-gradient(white, white), radial-gradient(circle at top left, rgba(5, 82, 171, 1), rgba(0, 219, 146, 1));
  background-origin: border-box;
  background-clip: content-box, border-box;
  }
}
`