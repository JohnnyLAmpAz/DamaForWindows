# Protocollo di comunicazione tra Client e Server

Qui vengono definte le strutture delle **richieste** e **risposte** che intercorrono tra server e client.

## Discovery Broadcast

UDP port `55555`

### Request

Un client invia pacchetto UDP Broadcast nel tentativo di ottenere una risposta da un server, così scoprendo il suo IP.
All'interno del pacchetto ci dovrebbe essere la stringa `DamaServerDiscoveryRequest`.

### Response

Il server risponderà a sua volta con un pacchetto UDP diretto al client col messaggio `HereIAm!`.
