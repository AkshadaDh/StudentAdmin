import { List } from '@material-ui/core';
import react from 'react';

import React from 'react'

const GetOpe = () => {
    const [records,getrecords]=useState([]);

    useEffect(()=>{
        fetch("https://localhost:7184/Students/")
        .then(Response=> Response.json())
        .then(data=>getrecords(data))
        .catch(err=>console.log(err))
    },[])
  return (
    <div>
      <table>
        <ul>
            {records.map((list,index)=>
            (
                <li key={index}>{list.id}|{list.name}
                    
                </li>
            )
            )}
        </ul>
      </table>
    </div>
  )
}

export default GetOpe
