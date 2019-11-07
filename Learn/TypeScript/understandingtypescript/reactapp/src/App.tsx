import React from 'react';
import CounterOutput from './CounterOutput';

//interface IAppProps {}

interface IAppState {
  counterValue: number;
}

const App: React.FC = () => {
  return (
    <div style={{textAlign: "center"}}>
      <CounterOutput counter={1} />
      <button>Increment</button>
      <button>Decrement</button>
    </div>
  );
}

export default App;
