import styled  from 'styled-components'

export const Container = styled.div`
display:flex;
flex-direction:column;
height:100vh;
padding:100px;
background:#e3e9ff;
align-items:center;

.title{
    display:flex;
    align-items:center;
    width: 490px;
    padding:10px;
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
height:600px;
width:70%;
border-radius:10px;
flex-direction:column;
background:transparent;
padding:10px;
`
export const Item = styled.div`
display:flex;
cursor:pointer;
margin:10px;
justify-content:space-between;
padding:10px;
width:100%;
height:150px;
background: white;
border-radius:10px;
box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
transition: ease-in-out 400ms;

&:hover{
    box-shadow: rgba(14, 30, 37, 0.12) 0px 2px 4px 0px, rgba(14, 30, 37, 0.32) 0px 2px 16px 0px;
}

.infos{
    width: 100%;
    margin:0px 40px;
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
    margin:10px
}
`