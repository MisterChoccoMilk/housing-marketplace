import * as React from "react";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import "./Modal.css";
import { Button } from "react-bootstrap";

const style = {
  position: "absolute",
  top: "55%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 600,
  bgcolor: "background.paper",
  boxShadow: 24,
  p: 4,
  borderRadius: "8px",
};

export default function InfoModal() {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  return (
    <div>
      <Button onClick={handleOpen} className="modal-button">
        ABOUT REGISTERED USERS
      </Button>
      <Modal open={open} onClose={handleClose}>
        <Box sx={style}>
          <Typography id="modal-modal-title" variant="h6" component="h2">
            INFORMATION
          </Typography>
          <Typography id="modal-modal-description" sx={{ mt: 1 }}>
            <b>Registered user</b>
          </Typography>
          <Typography id="modal-modal-description" sx={{ mt: 1 }}>
            Can register, CRUD of advertisment
          </Typography>
          
          <Typography id="modal-modal-description" sx={{ mt: 1 }}>
            <b>Administrator</b>
          </Typography>
          <Typography id="modal-modal-description" sx={{ mt: 1 }}>
            Manage registered users
          </Typography>
          <Typography id="modal-modal-description" sx={{ mt: 1 }}>
            CRUD of categories
          </Typography>
          <Typography id="modal-modal-description" sx={{ mt: 1 }}>
            Do everything that user can
          </Typography>
        </Box>
      </Modal>
    </div>
  );
}
