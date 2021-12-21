import React, { createContext, useState, useEffect, useContext } from "react";

interface CurrentAuction {
  id: string;
  name: string;
  image: string;
  price: string;
  date:string;
  about?:string;
  priceMin:number;
  time:number;
}
interface StateContextData {
  currentAuction: CurrentAuction | null;
  loading: boolean;
  setAuction(Auction:CurrentAuction): void;
}

const StateContext = createContext<StateContextData>({} as StateContextData);

const StateProvider: React.FC = ({ children }) => {
  const [currentAuction, setCurrentAuction] = useState<CurrentAuction | null>(null);
  const [loading, setLoading] = useState(false);

  function setAuction(Auction:CurrentAuction){
    setCurrentAuction(Auction);
  }

  return (
    <StateContext.Provider
      value={{ currentAuction, loading, setAuction }}
    >
      {children}
    </StateContext.Provider>
  );
};

function useCurrent() {
  const context = useContext(StateContext);

  if (!context) {
    throw new Error("useCurrent must be used within an AuthProvider.");
  }

  return context;
}

export { StateProvider, useCurrent };
