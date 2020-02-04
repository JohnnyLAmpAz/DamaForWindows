# Protocollo di comunicazione tra Client e Server

Qui vengono definte le strutture delle **richieste** e **risposte** che intercorrono tra server e client.

## Discovery Broadcast

Unico servizio che utilizza UDP.

UDP port `55555`

### Request Discovery

Un client invia pacchetto UDP Broadcast nel tentativo di ottenere una risposta da un server, così scoprendo il suo IP.
All'interno del pacchetto ci dovrebbe essere la stringa `DamaServerDiscoveryRequest`.

### Response Discovery

Il server risponderà a sua volta con un pacchetto UDP diretto al client col messaggio `HereIAm!`.

## Lobbies

Il server ospita tutte le partite, ma i client si devono dunque "incontrare" in qualche modo. Viene attivato un sistema fatto a *lobby*, dei client possono:

- Crearne una nuova ed aspettare che un altro giocatore si unisca

oppure

- Consultare la lista di quelle disponibili (create da altri) ed unirsi ad una.

### List

Richiesta con la stringa `ListAvailableLobbies` -> Risposta con lista di *Lobby* in JSON pronta da Deserializzare.

### Create

Richiesta in JSON:

```json
{
    req: "CreateLobby",
    nome: "<nome>"
}
```

Risposta a buon fine: `OK`

### Join

## Response Errors

### `E0`

Invalid Request
