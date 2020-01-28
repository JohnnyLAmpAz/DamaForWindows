# Protocollo di comunicazione tra Client e Server

Qui vengono definte le strutture delle **richieste** e **risposte** in formato **JSON**

## Discovery Broadcast

### REQUEST

Un client invia pacchetto UDP Broadcast nel tentativo di ottenere una risposta da un server, così scoprendo il suo IP.
All'interno del pacchetto ci dovrebbe essere questa stringa `DamaServerDiscoveryRequest`.

### RESPONSE


